/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.prog2.labs;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.time.LocalDate;

/**
 *
 * @author Amer-
 */
import java.util.ArrayList;
import java.util.List;

public class Library {

    private List<Book> books;
    private List<Student> students;

    public Library() {
        this.books = new ArrayList<>();
        this.students = new ArrayList<>();
    }

    public void addBook(Book book) {
        books.add(book);
    }

    public void removeBook(Book book) {
        books.remove(book);
    }

    public void addStudent(Student student) {
        students.add(student);
    }

    public void removeStudent(Student student) {
        students.remove(student);
    }

    public List<Book> getAllBooks() {
        return books;
    }

    public List<Student> getAllStudents() {
        return students;
    }
    
    public void addAllStudents(List<Student> students){
        this.students = students;
    }
    
    public void addAllBooks(List<Book> books){
        this.books = books;
    }
    
    /**
     * Find student by name
     * @param name
     * @return student object found
     */
    public Student findStudentByName(String name) {
        for (Student student : students) {
            if (student.getStudentName().equalsIgnoreCase(name)) {
                return student;
            }
        }
        return null;
    }

    /**
     * Find book by title
     * @param title
     * @return book object found
     */
    public Book findBookByTitle(String title) {
        for (Book book : books) {
            if (book.getTitle().equalsIgnoreCase(title)) {
                return book;
            }
        }
        return null;
    }
}
