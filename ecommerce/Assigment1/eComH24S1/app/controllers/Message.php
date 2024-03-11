<?php
namespace app\controllers;

use stdClass;

class Message extends \app\core\Controller
{

    function contact()
    {
        $this->view('Message/contact');
    }

    public function read()
    {
        if ($_SERVER['REQUEST_METHOD'] === 'POST') {
            // Create a new Message object with form data
            $message = new \app\models\Message();
            $message->email = $_POST['email'] ?? '';
            $message->message = $_POST['message'] ?? '';
            $message->IP = $_SERVER['REMOTE_ADDR'];

            // Insert the message into the file
            $message->insert();
        }

        // Call the read method of the Message model to retrieve messages
        $messages = \app\models\Message::getAll();
        
        // Pass the messages to the view for display
        $this->view('Message/read', ['messages' => $messages]);
    }
}