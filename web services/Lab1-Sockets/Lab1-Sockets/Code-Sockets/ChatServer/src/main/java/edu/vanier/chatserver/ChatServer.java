package edu.vanier.chatserver;

/**
 *
 * @author Sleiman Rabah
 */
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;

public class ChatServer {

    // The port number on wich the server will be listening to incoming
    // client requests. 
    public static int SERVER_PORT = 5000;
    private int counter = 0;

    /**
     * Creates and starts a server socket.
     *
     * @return the newly created server socket.
     */
    private ServerSocket startServer() {
        ServerSocket serverSocket = null;
        try {
            //-- Step 1) create a server socket.
            serverSocket = new ServerSocket(SERVER_PORT);
        } catch (IOException e) {
            System.out.println("SERVER> Error creating network connection");
        }
        System.out.println("SERVER> up and running...");
        return serverSocket;
    }

    // Handle all requests 
    private void handleRequests(ServerSocket serverSocket) {
        // Continuously serve the client.
        while (true) {
            Socket clientSocket = null;
            BufferedReader inputFromClient = null;
            PrintWriter outputToClient = null;

            try {
                //-- Step 2) Wait for an incoming client request.
                clientSocket = serverSocket.accept();
                // At this point, a client connection has been established.                 

                //-- Step 3) Create reading and writing streams.
                //--> inputFromClient: Holds the incoming requests.
                inputFromClient = new BufferedReader(new InputStreamReader(
                        clientSocket.getInputStream()));
                //--> outputToClient: Holds the responses to be sent to the client.
                outputToClient = new PrintWriter(clientSocket.getOutputStream());

            } catch (IOException e) {
                System.out.println("SERVER> Error connecting to client");
                System.exit(-1);
            }
            try {
                StringBuilder sb = new StringBuilder();
                // Parse the client's request (aka the message received). 
                // a) Retrieve the command sent by the client (from the received message).
                String requestCommand = inputFromClient.readLine();

                // b) Retrieve the body of the message sent by the client.
                String request;
                while (inputFromClient.ready() && (request = inputFromClient.readLine()) != null) {
                    sb.append(request);
                    sb.append('\n');
                }
                String requestBody = sb.toString().trim();
                System.out.println("SERVER> Client Message Received: " + requestBody);
                // Process the client's request.
                switch (requestCommand) {
                    case ProtocolConstants.CMD_GET_TIME -> {
                        outputToClient.println(new java.util.Date());
                        counter++;
                    }
                    case ProtocolConstants.CMD_GET_NBR_REQUEST -> {
                        outputToClient.println(counter++);
                    }
                    case ProtocolConstants.CMD_GET_FAVORITE_COLOR -> {
                        // Send back server's favorite color.
                        outputToClient.println("...BLUE...");
                    }
                    case ProtocolConstants.CMD_GET_SUM -> {
                        outputToClient.println("...2+2=...");
                        outputToClient.println("...4...");
                    }
                    case ProtocolConstants.CMD_GET_FAVORITE_DRINK -> {
                        outputToClient.println("...CocoCola...");
                        outputToClient.println("...CocoColaZero...");
                    }
                    case ProtocolConstants.CMD_GET_WEATHER -> {
                        outputToClient.println("Sunny");
                        outputToClient.println("25 degrees celsius");
                    }
                    default -> {
                        System.out.println("SERVER> Unknown request: " + requestBody + " " + requestCommand);
                    }
                }

                // Now make sure that the response is sent
                // NOTES: Communication through sockets is always buffered. 
                // This means nothing is sent or received until the buffers fill up,
                // or you explicitly flush the buffer. 
                outputToClient.flush();
                clientSocket.close();    // We are done with the client's request

            } catch (IOException e) {
                System.out.println("SERVER> Error communicating with client");
            }
        }
    }

    public static void main(String[] args) {
        ChatServer serverApp = new ChatServer();
        ServerSocket serverSocket = serverApp.startServer();
        if (serverSocket != null) {
            serverApp.handleRequests(serverSocket);
        }
    }
}
