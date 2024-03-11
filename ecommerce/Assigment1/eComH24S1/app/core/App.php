<?php
namespace app\core;

class App
{
    function __construct()
    {

        $url = isset($_GET['url']) ? $_GET['url'] : '';

        $routes = [
            'Main/index' => 'MainController,index',
            'Main/about_us' => 'MainController,about_us',
            'Message/contact' => 'Message,contact',
            'Message/read' => 'Message,read',
        ];

        //one by one compare the url to resolve the route
        foreach ($routes as $routeUrl => $controllerMethod) {
            if ($url == $routeUrl) {//match the route
                //run the route
                [$controller, $method] = explode(',', $controllerMethod);
                $controller = '\\app\\controllers\\' . $controller;
                $controller = new $controller();
                $controller->$method();
                //make sure that we don't run a second route
                break;
            }
        }


    }
}