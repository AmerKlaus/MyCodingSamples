/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.prog2.labs;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;

/**
 *
 * @author Amer-
 */
public class InsertStudents {

    private Connection connection = MyProject.getConnection();
    private Student student;

    /**
     * Insert students into the database
     * @param studentId
     * @param name
     * @param contact 
     */
    public void insertStudent(String studentId, String name, String contact) {
        String insertQuery = "INSERT INTO Students (StudentId, Name, Contact) VALUES (?, ?, ?)";
        try (PreparedStatement preparedStatement = connection.prepareStatement(insertQuery)) {
            preparedStatement.setString(1, studentId);
            preparedStatement.setString(2, name);
            preparedStatement.setString(3, contact);

            preparedStatement.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
