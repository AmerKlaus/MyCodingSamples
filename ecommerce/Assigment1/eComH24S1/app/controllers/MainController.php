<?php
namespace app\controllers;

class MainController extends \app\core\Controller
{

	public function index()
	{

		$this->view('Main/index');
	}

	public function about_us()
	{
		//Lands on the about us page view
		$this->view('Main/about_us');
	}
}

?>