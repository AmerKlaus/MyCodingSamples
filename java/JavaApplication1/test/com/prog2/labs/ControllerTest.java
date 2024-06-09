/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/UnitTests/JUnit4TestClass.java to edit this template
 */
package com.prog2.labs;

import java.util.List;
import java.util.Map;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Amer-
 */
public class ControllerTest {

    Library library = new Library();
    MainForm main = new MainForm();
    ContentForm content = new ContentForm();
    DataFetcher fetch = new DataFetcher();

    public ControllerTest() {
    }

    @BeforeClass
    public static void setUpClass() {
    }

    @AfterClass
    public static void tearDownClass() {
    }

    @Before
    public void setUp() {
        content.serialTextField.setText("123");
        content.titleTextField.setText("title");
        content.authorTextField.setText("author");
        content.publisherTextField.setText("publisher");
        content.priceTextField.setText("444");
        content.quantityTextField.setText("555");
        library.addAllBooks(fetch.fetchBooks());
        library.addAllStudents(fetch.fetchStudents());
        library.findBookByTitle("majd book");
        library.findBookByTitle("amer book");
        library.findStudentByName("John Cena");
        content.studentNameTextField.setText("John Cena");
        content.bookTitleTextField.setText("majd book");
    }

    @After
    public void tearDown() {
    }

    /**
     * Test of addBook method, of class Controller.
     */
    @Test
    public void testAddBook() {
        System.out.println("addBook");
        Controller instance = Controller.getInstance(library, main, content);;
        String expResult = "Successfully added book";
        String result = instance.addBook();
        assertEquals(expResult, result);
    }

    /**
     * Test of borrowBook method, of class Controller.
     */
    @Test
    public void testBorrowBook() {
        System.out.println("borrowBook");
        Controller instance = Controller.getInstance(library, main, content);
        String expResult = "success";
        String result = instance.borrowBook();
        assertEquals(expResult, result);
    }

    /**
     * Test of returnBook method, of class Controller.
     */
    @Test
    public void testReturnBook() {
        System.out.println("returnBook");
        Controller instance = Controller.getInstance(library, main, content);
        String expResult = "success";
        String result = instance.returnBook();
        assertEquals(expResult, result);
    }

    /**
     * Test of issueBook method, of class Controller.
     */
    @Test
    public void testIssueBook() {
        System.out.println("issueBook");
        Controller instance = Controller.getInstance(library, main, content);
        String expResult = "success";
        String result = instance.issueBook();
        assertEquals(expResult, result);
    }

    /**
     * Test of issueReturn method, of class Controller.
     */
    @Test
    public void testIssueReturn() {
        System.out.println("issueReturn");
        Controller instance = Controller.getInstance(library, main, content);
        instance.issueBook();
        String expResult = "success";
        String result = instance.issueReturn();
        assertEquals(expResult, result);
    }

    /**
     * Test of viewAllBooks method, of class Controller.
     */
    @Test
    public void testViewAllBooks() {
        System.out.println("viewAllBooks");
        Controller instance = Controller.getInstance(library, main, content);
        Map<String, String> catalog = library.getAllBooks().get(0).viewCatalog();

        StringBuilder expResult = new StringBuilder();

        for (Map.Entry<String, String> entry : catalog.entrySet()) {
            String serialNumber = entry.getKey();
            String bookInfo = entry.getValue();
            expResult.append("Serial Number: ").append(serialNumber).append("\n")
                    .append(bookInfo).append("\n\n");
        }
        String result = instance.viewAllBooks();
        assertEquals(expResult.toString(), result);
    }

    /**
     * Test of viewIssuedBooks method, of class Controller.
     */
    @Test
    public void testViewIssuedBooks() {
        System.out.println("viewIssuedBooks");
        Controller instance = Controller.getInstance(library, main, content);
        Map<String, String> catalog = library.getAllBooks().get(0).viewIssuedBooks();

        StringBuilder expResult = new StringBuilder();

        for (Map.Entry<String, String> entry : catalog.entrySet()) {
            String issuedBookID = entry.getKey();
            String bookInfo = entry.getValue();
            expResult.append("Issued Book ID: ").append(issuedBookID).append("\n")
                    .append(bookInfo).append("\n\n");
        }
        String result = instance.viewIssuedBooks();
        assertEquals(expResult.toString(), result);
    }

    /**
     * Test of searchBooksByTitle method, of class Controller.
     */
    @Test
    public void testSearchBooksByTitle() {
        System.out.println("searchBooksByTitle");
        String title = "title";
        Controller instance = Controller.getInstance(library, main, content);
        List<Book> books = library.getAllStudents().get(0).searchByTitle(title);
        String expResult = formatBooksToString(books);;
        String result = instance.searchBooksByTitle(title);
        assertEquals(expResult, result);
    }

    /**
     * Test of searchBooksByAuthor method, of class Controller.
     */
    @Test
    public void testSearchBooksByAuthor() {
        System.out.println("searchBooksByAuthor");
        String author = "author";
        Controller instance = Controller.getInstance(library, main, content);
        List<Book> books = library.getAllStudents().get(0).searchByAuthor(author);
        String expResult = formatBooksToString(books);;
        String result = instance.searchBooksByAuthor(author);
        assertEquals(expResult, result);
    }

    /**
     * Test of searchBooksByPublisher method, of class Controller.
     */
    @Test
    public void testSearchBooksByPublisher() {
        System.out.println("searchBooksByPublisher");
        String publisher = "publisher";
        Controller instance = Controller.getInstance(library, main, content);
        List<Book> books = library.getAllStudents().get(0).searchByPublisher(publisher);
        String expResult = formatBooksToString(books);;
        String result = instance.searchBooksByPublisher(publisher);
        assertEquals(expResult, result);
    }

    private String formatBooksToString(List<Book> books) {
        StringBuilder result = new StringBuilder();

        for (Book book : books) {
            result.append(book.toString()).append("\n\n");
        }

        return result.toString();
    }

}
