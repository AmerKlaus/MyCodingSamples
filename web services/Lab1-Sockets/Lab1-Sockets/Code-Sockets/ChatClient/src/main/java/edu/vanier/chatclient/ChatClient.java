package edu.vanier.chatclient;

/**
 *
 * @author Sleiman Rabah
 */
import java.net.*;
import java.io.*;
import java.util.logging.Level;
import java.util.logging.Logger;

public class ChatClient {

    private final int SERVER_PORT = 5000;
    private Socket clientSocket;
    private BufferedReader inputFromServer;
    private PrintWriter outputToServer;

    /**
     * Creates a connection to a server.
     */
    private void connectToServer() {
        try {
            //-- Step 1)  Create a client socket to connect to the server.             
            // This is the endpoint of the client/server communication.
            //TODO: change the IP address below if you would like to connect 
            //     to a server running on another computer. 
            //@see: https://docs.oracle.com/javase/7/docs/api/java/net/Socket.html
            //--
            clientSocket = new Socket(InetAddress.getLocalHost(), SERVER_PORT);

            //-- Step 2) Create an output stream to send data to the server.
            // Used for sending a request to the server.
            outputToServer = new PrintWriter(clientSocket.getOutputStream());

            //-- Step 3)Create an input stream to read data from the server
            // Used for receiving a rerequest from the server.
            inputFromServer = new BufferedReader(
                    new InputStreamReader(
                            clientSocket.getInputStream()));
        } catch (IOException e) {
            System.out.println("CLIENT: Cannot connect to server");
            System.exit(-1);
        }
    }

    /**
     * Disconnect from the server.
     */
    private void disconnectFromServer() {
        try {
            clientSocket.close();
        } catch (IOException e) {
            System.out.println("CLIENT: Cannot disconnect from server");
        }
    }

    /**
     * Ask the server for the current time.
     */
    private void askForTime() {
        connectToServer();
        //-- Prepare the REQUEST to be sent to the server.                                     
        //--
        //-- Setting up the message structure.
        //-- Step 1) The first line must be the command.
        outputToServer.println(ProtocolConstants.CMD_GET_TIME);
        //-- Step 2) The second line must be the message.
        outputToServer.println("What Time is It ?");
        //-- Step 3) send the request by "flushing" the buffer.
        outputToServer.flush();
        try {
            //-- Process the obtained RESPONSE. 
            String time = inputFromServer.readLine();
            System.out.println("CLIENT> The time is " + time);
        } catch (IOException e) {
            System.out.println("CLIENT> Cannot receive time from server");
        }
        disconnectFromServer();
    }

    /**
     * Ask the server for the number of requests obtained.
     */
    private void askForNumberOfRequests() {
        connectToServer();
        outputToServer.println(ProtocolConstants.CMD_GET_NBR_REQUEST);
        outputToServer.println("How many requests have you handled ?");
        outputToServer.flush();
        int count = 0;
        try {
            count = Integer.parseInt(inputFromServer.readLine());
        } catch (IOException e) {
            System.out.println("CLIENT> Cannot receive num requests from server");
        }
        System.out.println("CLIENT> The number of requests handled is: " + count);
        disconnectFromServer();
    }

    /**
     * Ask the server for its favorite color.
     */
    private void askForFavoriteColor() {
        try {
            connectToServer();
            outputToServer.println(ProtocolConstants.CMD_GET_FAVORITE_COLOR);
            outputToServer.println("What is your favorite color?");
            outputToServer.flush();
            String time = inputFromServer.readLine();
            System.out.println("CLIENT> Server's favorite color is " + time);
            disconnectFromServer();
        } catch (IOException ex) {
            Logger.getLogger(ChatClient.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * Ask the server for the sum of 2 + 2
     */
    private void askForSum() {
        try {
            connectToServer();
            outputToServer.println(ProtocolConstants.CMD_GET_SUM);
            outputToServer.println("What is the substraction of 2 + 2?");
            outputToServer.println("I mean sum");
            outputToServer.flush();
            StringBuilder sb = new StringBuilder();
            String request;
            while ((request = inputFromServer.readLine()) != null) {
                sb.append(request);
                sb.append('\n');
            }
            String time = sb.toString().trim();
            System.out.println("CLIENT> The sum of " + time);
            disconnectFromServer();
        } catch (IOException ex) {
            Logger.getLogger(ChatClient.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * Ask the server for its favorite drink
     */
    private void askForFavoriteDrink() {
        try {
            connectToServer();
            outputToServer.println(ProtocolConstants.CMD_GET_FAVORITE_DRINK);
            outputToServer.println("What is your favorite drink?");
            outputToServer.println("I mean soda");
            outputToServer.flush();
            StringBuilder sb = new StringBuilder();
            String request;
            while ((request = inputFromServer.readLine()) != null) {
                sb.append(request);
                sb.append('\n');
            }
            String time = sb.toString().trim();
            System.out.println("CLIENT> Server's favorite drink is " + time);
            disconnectFromServer();
        } catch (IOException ex) {
            Logger.getLogger(ChatClient.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * Ask the server for the weather
     */
    private void askForWeather() {
        try {
            connectToServer();
            outputToServer.println(ProtocolConstants.CMD_GET_WEATHER);
            outputToServer.println("What is the weather?");
            outputToServer.println("For Today");
            outputToServer.flush();
            StringBuilder sb = new StringBuilder();
            String request;
            while ((request = inputFromServer.readLine()) != null) {
                sb.append(request);
                sb.append('\n');
            }
            String time = sb.toString().trim();
            System.out.println("CLIENT> The weather today is " + time);
            disconnectFromServer();
        } catch (IOException ex) {
            Logger.getLogger(ChatClient.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    private static void Delay() {
        try {
            Thread.sleep(500);
        } catch (InterruptedException e) {
        }
    }

    public static void main(String[] args) {
        ChatClient client = new ChatClient();
        Delay();
        client.askForTime();
        Delay();
        client.askForNumberOfRequests();
        Delay();
        client.askForFavoriteColor();
        Delay();
        client.askForNumberOfRequests();
        Delay();
        client.askForSum();
        Delay();
        client.askForFavoriteDrink();
        Delay();
        client.askForWeather();
    }

}
