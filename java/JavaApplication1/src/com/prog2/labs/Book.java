/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.prog2.labs;

import java.time.LocalDate;
import java.util.HashMap;
import java.util.Map;
import java.sql.ResultSet;
import java.sql.Statement;
import java.sql.PreparedStatement;
import java.sql.Connection;
import java.sql.SQLException;
import java.time.format.DateTimeFormatter;

/**
 *
 * @author Amer-
 */
public class Book {

    private final String SN;
    private String title;
    private String author;
    private String publisher;
    private int price;
    private int qte;
    private int issuedQte;
    private String dateOfPurchase;
    private Connection connection = MyProject.getConnection();

    /**
     * Constructor to assign values to the instances
     * @param SN
     * @param title
     * @param author
     * @param publisher
     * @param price
     * @param qte 
     */
    public Book(String SN, String title, String author, String publisher, int price, int qte) {
        this.SN = SN;
        this.title = title;
        this.author = author;
        this.publisher = publisher;
        this.price = price;
        this.qte = qte;
    }

    public String getSN() {
        return SN;
    }

    public String getTitle() {
        return title;
    }

    public String getAuthor() {
        return author;
    }

    public String getPublisher() {
        return publisher;
    }

    public int getPrice() {
        return price;
    }

    public int getQte() {
        return qte;
    }

    public int getIssuedQte() {
        return issuedQte;
    }

    public String getDateOfPurchase() {
        return dateOfPurchase;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public void setPublisher(String publisher) {
        this.publisher = publisher;
    }

    public void setPrice(int price) {
        this.price = price;
    }

    public void setQte(int qte) {
        this.qte = qte;
    }

    public void setIssuedQte(int issuedQte) {
        this.issuedQte = issuedQte;
    }

    public void setDateOfPurchase(String date) {
        this.dateOfPurchase = date;
    }

    /**
     * Add book to the database
     * @param book 
     */
    public void addBook(Book book) {
        String addQuery = "INSERT INTO Books (SN, Title, Author, Publisher, Price, Quantity, Issued, addedDate) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

        try (PreparedStatement addBook = connection.prepareStatement(addQuery);) {

            addBook.setString(1, book.getSN());
            addBook.setString(2, book.getTitle());
            addBook.setString(3, book.getAuthor());
            addBook.setString(4, book.getPublisher());
            addBook.setInt(5, book.getPrice());
            addBook.setInt(6, book.getQte());
            addBook.setInt(7, 0);
            addBook.setString(8, getCurrentDate());

            addBook.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    /**
     * Issue a book from the database to a student
     * @param book
     * @param student
     * @return if a book can be issued or not
     */
    public boolean issueBook(Book book, Student student) {
        String checkQuery = "SELECT Quantity, Issued FROM Books WHERE SN = ?";
        String qteQuery = "UPDATE Books SET Quantity = Quantity - 1, Issued = Issued + 1 WHERE SN = ?";
        String addQuery = "INSERT INTO IssuedBooks (SN, StId, StName, StudentContact, IssueDate) VALUES (?, ?, ?, ?, ?)";
        try (PreparedStatement checkAvailability = connection.prepareStatement(checkQuery); PreparedStatement updateBookQte = connection.prepareStatement(qteQuery); PreparedStatement addIssuedBookStmt = connection.prepareStatement(addQuery);) {

            // Check if the book is available
            checkAvailability.setString(1, book.getSN());
            ResultSet resultSet = checkAvailability.executeQuery();
            if (resultSet.next()) {
                int availableQuantity = resultSet.getInt("Quantity");

                if (availableQuantity > 0) {
                    // Update the Books table (decrease quantity and increase issued)
                    updateBookQte.setString(1, book.getSN());
                    updateBookQte.executeUpdate();

                    // Add entry to IssuedBooks table
                    addIssuedBookStmt.setString(1, book.getSN());
                    addIssuedBookStmt.setString(2, student.getStudentId());
                    addIssuedBookStmt.setString(3, student.getStudentName());
                    addIssuedBookStmt.setString(4, student.getContactNumber());
                    addIssuedBookStmt.setString(5, getCurrentDate());

                    addIssuedBookStmt.executeUpdate();

                    return true;
                }
            }

        } catch (SQLException e) {
            e.printStackTrace();
        }

        return false;
    }

    /**
     * Return a book from a student to the database
     * @param book
     * @param student
     * @return if a book can be returned or not
     */
    public boolean returnBook(Book book, Student student) {
        if (isBookIssued(book, student)) {
            try {
                // Update the book quantities in the Books table
                String updateQteQuery = "UPDATE Books SET Quantity = Quantity + 1, Issued = Issued - 1 WHERE SN = ?";
                try (PreparedStatement updateQuantityStatement = connection.prepareStatement(updateQteQuery)) {
                    updateQuantityStatement.setString(1, book.getSN());
                    updateQuantityStatement.executeUpdate();
                }

                // Delete the corresponding record from the IssuedBooks table
                String deleteIssuedBookQuery = "DELETE FROM IssuedBooks WHERE SN = ? AND StId = ?";
                try (PreparedStatement deleteIssuedBookStatement = connection.prepareStatement(deleteIssuedBookQuery)) {
                    deleteIssuedBookStatement.setString(1, book.getSN());
                    deleteIssuedBookStatement.setString(2, student.getStudentId());
                    deleteIssuedBookStatement.executeUpdate();
                }

                return true;
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }

        return false;
    }

    /**
     * Check if the book is issued
     * @param book
     * @param student
     * @return if the book is issued or not
     */
    private boolean isBookIssued(Book book, Student student) {
        try {
            String query = "SELECT * FROM IssuedBooks WHERE SN = ? AND StId = ?";
            try (PreparedStatement statement = connection.prepareStatement(query)) {
                statement.setString(1, book.getSN());
                statement.setString(2, student.getStudentId());
                try (ResultSet resultSet = statement.executeQuery()) {
                    return resultSet.next();
                }
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return false;
    }

    /**
     * View all books in the database
     * @return Catalog of all books in the database
     */
    public Map<String, String> viewCatalog() {
        Map<String, String> catalogMap = new HashMap<>();
        String resultSetQuery = "SELECT * FROM Books ORDER BY SN";

        try (Statement statement = connection.createStatement(); ResultSet resultSet = statement.executeQuery(resultSetQuery)) {

            while (resultSet.next()) {
                String serialNumber = resultSet.getString("SN");
                String title = resultSet.getString("Title");
                String author = resultSet.getString("Author");
                String publisher = resultSet.getString("Publisher");
                int price = resultSet.getInt("Price");
                int quantity = resultSet.getInt("Quantity");
                int issued = resultSet.getInt("Issued");
                String addedDate = resultSet.getString("addedDate");

                String bookInfo = String.format("Title: %s\nAuthor: %s\nPublisher: %s\nPrice: %d\n"
                        + "Quantity: %d\nIssued: %d\nAdded Date: %s",
                        title, author, publisher, price, quantity, issued, addedDate);

                catalogMap.put(serialNumber, bookInfo);
            }

        } catch (SQLException e) {
            e.printStackTrace();
        }

        return catalogMap;
    }

    /**
     * View all issued books in the database
     * @return Catalog of all issued books
     */
    public Map<String, String> viewIssuedBooks() {
        Map<String, String> issuedBooksMap = new HashMap<>();

        try (PreparedStatement statement = connection.prepareStatement("SELECT * FROM IssuedBooks ORDER BY SN"); ResultSet resultSet = statement.executeQuery()) {

            while (resultSet.next()) {
                String issuedBookId = resultSet.getString("id");
                String serialNumber = resultSet.getString("SN");
                String studentName = resultSet.getString("StName");
                String studentContact = resultSet.getString("StudentContact");
                String issueDate = resultSet.getString("IssueDate");

                String bookInfo = String.format("Book SN: %s\nStudent Name: %s\nStudent Contact: %s\nIssue Date: %s",
                        serialNumber, studentName, studentContact, issueDate);

                issuedBooksMap.put(issuedBookId, bookInfo);
            }

        } catch (SQLException e) {
            e.printStackTrace();
        }

        return issuedBooksMap;
    }

    /**
     * Get the current local date
     * @return String of current date
     */
    public String getCurrentDate() {
        LocalDate currentDate = LocalDate.now();

        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd");
        return currentDate.format(formatter);
    }

    /**
     * Format the list of books
     * @return String of books
     */
    @Override
    public String toString() {
        return String.format("Serial Number: %s\nTitle: %s\nAuthor: %s\nPublisher: %s\nPrice: %d\nQuantity: %d\nIssued: %d\nAdded Date: %s",
                this.SN, this.title, this.author, this.publisher, this.price, this.qte, this.issuedQte, this.dateOfPurchase);
    }
}
