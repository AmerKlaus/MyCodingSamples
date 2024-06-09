package com.prog2.labs;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;

/**
 *
 * @author Amer-
 */
public class MyProject {

    /**
     * Write your test code below in the main (optional).
     *
     * @param args
     */
    public static void main(String[] args) {
        initializeDatabase();
        
//        InsertStudents students = new InsertStudents();
//        students.insertStudent("S001", "John Cena", "1234567890");
//        students.insertStudent("S002", "Jane Doe", "9876543210");
//        students.insertStudent("S003", "Bobby Bobson", "2234521323");
        
        DataFetcher fetcher = new DataFetcher();

        MainForm mainForm = new MainForm();
        ContentForm contentForm = new ContentForm();
        Library library = new Library();
        library.addAllBooks(fetcher.fetchBooks());
        library.addAllStudents(fetcher.fetchStudents());
        Controller controller = Controller.getInstance(library, mainForm, contentForm);

        controller.showForm();

        Runtime.getRuntime().addShutdownHook(new Thread(() -> {
            closeConnection();
        }));
    }

    private static Connection connection = null;

    /**
     * Creates a database file and gets the connection
     * @return Connection
     */
    public static Connection getConnection() {
        try {
            // Connect to the SQLite database
            String url = "jdbc:sqlite:project.db";
            connection = DriverManager.getConnection(url);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return connection;
    }

    /**
     * Closes the connection
     */
    public static void closeConnection() {
        try {
            connection.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    /**
     * Initializes all the database tables
     */
    public static void initializeDatabase() {
        Connection connection = MyProject.getConnection();

        // Create tables if they don't exist
        createBooksTable(connection);
        createStudentsTable(connection);
        createIssuedBooksTable(connection);
    }

    /**
     * Creates book table in the database
     * @param connection 
     */
    private static void createBooksTable(Connection connection) {
        String createTableQuery = "CREATE TABLE IF NOT EXISTS Books ("
                + "SN TEXT PRIMARY KEY,"
                + "Title TEXT NOT NULL,"
                + "Author TEXT NOT NULL,"
                + "Publisher TEXT NOT NULL,"
                + "Price INTEGER NOT NULL,"
                + "Quantity INTEGER,"
                + "Issued INTEGER DEFAULT 0,"
                + "addedDate TEXT)";

        try (PreparedStatement createTableStatement = connection.prepareStatement(createTableQuery)) {
            createTableStatement.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    /**
     * Creates student table in the database
     * @param connection 
     */
    private static void createStudentsTable(Connection connection) {
        String createTableQuery = "CREATE TABLE IF NOT EXISTS Students ("
                + "StudentId TEXT PRIMARY KEY,"
                + "Name TEXT NOT NULL,"
                + "Contact TEXT)";

        try (PreparedStatement createTableStatement = connection.prepareStatement(createTableQuery)) {
            createTableStatement.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    /**
     * Creates Issued Books table in the database
     * @param connection 
     */
    private static void createIssuedBooksTable(Connection connection) {
        String createTableQuery = "CREATE TABLE IF NOT EXISTS IssuedBooks ("
                + "id INTEGER PRIMARY KEY AUTOINCREMENT,"
                + "SN TEXT REFERENCES Books(SN),"
                + "StId TEXT REFERENCES Students(StudentId),"
                + "StName TEXT,"
                + "StudentContact TEXT,"
                + "IssueDate TEXT)";

        try (PreparedStatement createTableStatement = connection.prepareStatement(createTableQuery)) {
            createTableStatement.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    /**
     * Please refer to the README file for question(s) description
     */
}
