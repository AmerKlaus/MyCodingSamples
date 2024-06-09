/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.prog2.labs;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Amer-
 */
public class DataFetcher {

    /**
     * Fetch all books from the database
     * @return List of books
     */
    public List<Book> fetchBooks() {
        List<Book> books = new ArrayList<>();
        try (Connection connection = MyProject.getConnection(); Statement statement = connection.createStatement()) {
            String query = "SELECT * FROM Books";
            try (ResultSet resultSet = statement.executeQuery(query)) {
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

                    books.add(book);
                }
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return books;
    }

    /**
     * Fetch all students from the database
     * @return List of students
     */
    public List<Student> fetchStudents() {
        List<Student> students = new ArrayList<>();
        try (Connection connection = MyProject.getConnection(); Statement statement = connection.createStatement()) {
            String query = "SELECT * FROM Students";
            try (ResultSet resultSet = statement.executeQuery(query)) {
                while (resultSet.next()) {
                    String id = resultSet.getString("StudentId");
                    String name = resultSet.getString("Name");
                    String contact = resultSet.getString("Contact");

                    Student student = new Student(id, name, contact);

                    students.add(student);
                }
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        return students;
    }
}
