/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.prog2.labs;

import java.util.List;
import java.util.Map;

/**
 *
 * @author Amer-
 */
public class Controller {

    private Library library;
    private MainForm mainFormView;
    private ContentForm contentFormView;
    private static Controller controllerObject;

    /**
     * Empty Constructor
     */
    private Controller() {

    }

    /**
     * Private Constructor to assign values to the instances
     * @param library
     * @param mainFormView
     * @param contentFormView 
     */
    private Controller(Library library, MainForm mainFormView, ContentForm contentFormView) {
        this.library = library;
        this.mainFormView = mainFormView;
        this.contentFormView = contentFormView;
    }

    /**
     * Get instances of controller class without initializing constructor
     * @return Controller object that is initialized
     */
    public static Controller getInstance() {
        // create object if it's not already created
        if (controllerObject == null) {
            controllerObject = new Controller();
        }

        // returns the singleton object
        return controllerObject;
    }

    /**
     * Get instances of controller class without initializing constructor
     * @param library
     * @param mainFormView
     * @param contentFormView
     * @return Controller object that is initialized
     */
    public static Controller getInstance(Library library, MainForm mainFormView, ContentForm contentFormView) {
        // create object if it's not already created
        if (controllerObject == null) {
            controllerObject = new Controller(library, mainFormView, contentFormView);
        }

        // returns the singleton object
        return controllerObject;
    }

    /**
     * Sets library object
     * @param library 
     */
    public void setLibrary(Library library) {
        this.library = library;
    }

    /**
     * Sets content form object
     * @param contentFormView 
     */
    public void setContentFormView(ContentForm contentFormView) {
        this.contentFormView = contentFormView;
    }

    /**
     * Gets library object
     * @return library object
     */
    public Library getLibrary() {
        return library;
    }

    /**
     * Opens main form
     */
    public void showForm() {
        mainFormView.show();
    }

    /**
     * Adds book to the database
     * @return status of whether the book was added or not
     */
    public String addBook() {
        String serialNumber = contentFormView.serialTextField.getText();
        String title = contentFormView.titleTextField.getText();
        String author = contentFormView.authorTextField.getText();
        String publisher = contentFormView.publisherTextField.getText();
        String price = contentFormView.priceTextField.getText();
        String quantity = contentFormView.quantityTextField.getText();
        String status = "";
        Library selectedLibrary = null;

        if (!serialNumber.equals("") && !title.equals("") && !author.equals("") && !publisher.equals("") && !price.equals("")) {
            try {
                int parsedPrice = Integer.parseInt(price);
                int parsedQuantity = Integer.parseInt(quantity);

                Book newBook = new Book(serialNumber, title, author, publisher, parsedPrice, parsedQuantity);
                newBook.addBook(newBook);
                library.addBook(newBook);
                status = "Successfully added book";
            } catch (NumberFormatException e) {
                System.out.println(e);
                status = "Make sure price and quantity are numbers!";
            }
        } else {
            status = "All fields except for quantity cannot be null!";
        }

        selectedLibrary = library;

        contentFormView.setLibrary(selectedLibrary);

        return status;
    }

    /**
     * Borrows book for a student from the database
     * @return Status whether book is borrowed or not
     */
    public String borrowBook() {
        String studentName = contentFormView.studentNameTextField.getText();
        String title = contentFormView.bookTitleTextField.getText();
        Library selectedLibrary = null;
        String status = "";

        Student student = library.findStudentByName(studentName);
        Book book = library.findBookByTitle(title);

        if (student != null && book != null) {
            if (student.borrow(book)) {
                status = "success";
            } else {
                status = "failure";
            }
        } else {
            status = "student name or book title does not exist!";
        }

        selectedLibrary = library;

        contentFormView.setLibrary(selectedLibrary);

        return status;
    }

    /**
     * Returns a book for a student in the database
     * @return status whether book is return or not
     */
    public String returnBook() {
        String studentName = contentFormView.studentNameTextField.getText();
        String title = contentFormView.bookTitleTextField.getText();
        Library selectedLibrary = null;
        String status = "";

        Student student = library.findStudentByName(studentName);
        Book book = library.findBookByTitle(title);

        if (student != null && book != null) {
            if (student.toReturn(book)) {
                status = "success";
            } else {
                status = "failure";
            }
        } else {
            status = "student name or book title does not exist!";
        }

        selectedLibrary = library;

        contentFormView.setLibrary(selectedLibrary);

        return status;
    }

    /**
     * Issues a book for the librarian in the database
     * @return status whether book is issued or not
     */
    public String issueBook() {
        String studentName = contentFormView.studentNameTextField.getText();
        String title = contentFormView.bookTitleTextField.getText();
        Library selectedLibrary = null;
        String status = "";

        Student student = library.findStudentByName(studentName);
        Book book = library.findBookByTitle(title);

        if (student != null && book != null) {
            if (book.issueBook(book, student)) {
                status = "success";
            } else {
                status = "failure";
            }
        } else {
            status = "student name or book title does not exist!";
        }

        selectedLibrary = library;

        contentFormView.setLibrary(selectedLibrary);

        return status;
    }

    /**
     * Returns a book for the librarian in the database
     * @return status whether book is returned or not
     */
    public String issueReturn() {
        String studentName = contentFormView.studentNameTextField.getText();
        String title = contentFormView.bookTitleTextField.getText();
        Library selectedLibrary = null;
        String status = "";

        Student student = library.findStudentByName(studentName);
        Book book = library.findBookByTitle(title);

        if (student != null && book != null) {
            if (book.returnBook(book, student)) {
                status = "success";
            } else {
                status = "failure";
            }
        } else {
            status = "student name or book title does not exist!";
        }

        selectedLibrary = library;

        contentFormView.setLibrary(selectedLibrary);

        return status;
    }

    /**
     * Views all books in the database
     * @return List of all books
     */
    public String viewAllBooks() {
        if (library.getAllBooks() != null) {
            Map<String, String> catalog = library.getAllBooks().get(0).viewCatalog();

            StringBuilder result = new StringBuilder();

            for (Map.Entry<String, String> entry : catalog.entrySet()) {
                String serialNumber = entry.getKey();
                String bookInfo = entry.getValue();
                result.append("Serial Number: ").append(serialNumber).append("\n")
                        .append(bookInfo).append("\n\n");
            }

            return result.toString();
        }else {
            return "there are no books";
        }
    }

    /**
     * View all issued Books in the database
     * @return List of all issued books
     */
    public String viewIssuedBooks() {
        if (library.getAllBooks() != null) {
            Map<String, String> catalog = library.getAllBooks().get(0).viewIssuedBooks();

            StringBuilder result = new StringBuilder();

            for (Map.Entry<String, String> entry : catalog.entrySet()) {
                String issuedBookID = entry.getKey();
                String bookInfo = entry.getValue();
                result.append("Issued Book ID: ").append(issuedBookID).append("\n")
                        .append(bookInfo).append("\n\n");
            }

            return result.toString();
        } else {
            return "there are no issued books";
        }
    }

    /**
     * Search all books by title in the database
     * @param title
     * @return List of searched books
     */
    public String searchBooksByTitle(String title) {
        List<Book> books = library.getAllStudents().get(0).searchByTitle(title);
        return formatBooksToString(books);
    }

    /**
     * Search all books by Author in the database
     * @param author
     * @return List of searched books
     */
    public String searchBooksByAuthor(String author) {
        List<Book> books = library.getAllStudents().get(0).searchByAuthor(author);
        return formatBooksToString(books);
    }

    /**
     * Search all books by publisher in the database
     * @param publisher
     * @return List of searched books
     */
    public String searchBooksByPublisher(String publisher) {
        List<Book> books = library.getAllStudents().get(0).searchByPublisher(publisher);
        return formatBooksToString(books);
    }

    /**
     * Formats the list of books searched in the database into one string
     * @param books
     * @return Formatted list of books
     */
    private String formatBooksToString(List<Book> books) {
        StringBuilder result = new StringBuilder();

        for (Book book : books) {
            result.append(book.toString()).append("\n\n");
        }

        return result.toString();
    }
}
