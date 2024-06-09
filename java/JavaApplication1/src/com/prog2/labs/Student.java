/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.prog2.labs;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.sql.ResultSet;
import java.sql.Statement;
import java.sql.PreparedStatement;
import java.sql.Connection;
import java.sql.SQLException;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;

/**
 *
 * @author Amer-
 */
public class Student {
    private String studentId;
    private String studentName;
    private String contactNumber;
    private Connection connection = MyProject.getConnection();

    /**
     * Constructor to assign values to the instances
     * @param studentId
     * @param studentName
     * @param contactNumber 
     */
    public Student(String studentId, String studentName, String contactNumber) {
        this.studentId = studentId;
        this.studentName = studentName;
        this.contactNumber = contactNumber;
    }

    public String getStudentId() {
        return studentId;
    }

    public String getStudentName() {
        return studentName;
    }

    public String getContactNumber() {
        return contactNumber;
    }

    public void setStudentId(String studentId) {
        this.studentId = studentId;
    }

    public void setStudentName(String studentName) {
        this.studentName = studentName;
    }

    public void setContactNumber(String contactNumber) {
        this.contactNumber = contactNumber;
    }
    
    /**
     * Borrow book from the database
     * @param book
     * @return if book is borrowed or not
     */
    public boolean borrow(Book book) {
        String checkQuery = "SELECT Quantity, Issued FROM Books WHERE SN = ?";
        String qteQuery = "UPDATE Books SET Quantity = Quantity - 1, Issued = Issued + 1 WHERE SN = ?";
        String addQuery = "INSERT INTO IssuedBooks (SN, StId, StName, StudentContact, IssueDate) VALUES (?, ?, ?, ?, ?)";
        try (PreparedStatement checkAvailability = connection.prepareStatement(checkQuery); 
                PreparedStatement updateBookQte = connection.prepareStatement(qteQuery); 
                PreparedStatement addIssuedBookStmt = connection.prepareStatement(addQuery);) {
            
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
                    addIssuedBookStmt.setString(2, this.getStudentId());
                    addIssuedBookStmt.setString(3, this.getStudentName());
                    addIssuedBookStmt.setString(4, this.getContactNumber());
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
     * Return book to the database
     * @param book
     * @return if book is returned or not
     */
    public boolean toReturn(Book book) {
        if (isBookIssued(book)) {
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
                    deleteIssuedBookStatement.setString(2, this.getStudentId());
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
     * Check if book is borrowed
     * @param book
     * @return if book is borrowed or not
     */
    private boolean isBookIssued(Book book) {
        try {
            String query = "SELECT * FROM IssuedBooks WHERE SN = ? AND StId = ?";
            try (PreparedStatement statement = connection.prepareStatement(query)) {
                statement.setString(1, book.getSN());
                statement.setString(2, this.getStudentId());
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
     * Search all books by title in the database
     * @param title
     * @return List of searched books
     */
    public List<Book> searchByTitle(String title) {
        return searchBooks("Title", title);
    }

    /**
     * Search all books by Author in the database
     * @param author
     * @return List of searched books
     */
    public List<Book> searchByAuthor(String author) {
        return searchBooks("Author", author);
    }

    /**
     * Search all books by publisher in the database
     * @param publisher
     * @return List of searched books
     */
    public List<Book> searchByPublisher(String publisher) {
        return searchBooks("Publisher", publisher);
    }
    
    /**
     * Search all books by certain criteria in the database
     * @param criteria
     * @param value
     * @return List of searched books
     */
    private List<Book> searchBooks(String criteria, String value) {
        List<Book> result = new ArrayList<>();

        try {
            String query = "SELECT * FROM Books WHERE " + criteria + " LIKE ? ORDER BY SN";
            try (PreparedStatement statement = connection.prepareStatement(query)) {
                statement.setString(1, "%" + value + "%");

                try (ResultSet resultSet = statement.executeQuery()) {
                    while (resultSet.next()) {
                        String serialNumber = resultSet.getString("SN");
                        String title = resultSet.getString("Title");
                        String author = resultSet.getString("Author");
                        String publisher = resultSet.getString("Publisher");
                        int price = resultSet.getInt("Price");
                        int quantity = resultSet.getInt("Quantity");
                        int issued = resultSet.getInt("Issued");
                        String addedDate = resultSet.getString("addedDate");
                        
                        Book book = new Book(serialNumber, title, author, publisher, price, quantity);
                        book.setIssuedQte(issued);
                        book.setDateOfPurchase(addedDate);

                        result.add(book);
                    }
                }
            }
        } catch (SQLException e) {
            e.printStackTrace(); // Handle the exception appropriately in your application
        }

        return result;
    }
    
    /**
     * Get current local date
     * @return String of current date
     */
    public String getCurrentDate() {
        LocalDate currentDate = LocalDate.now();

        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd");
        return currentDate.format(formatter);
    }
}
