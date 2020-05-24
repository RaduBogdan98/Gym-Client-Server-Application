<?php
require('class.phpmailer.php');
require('class.smtp.php');
require('PHPMailerAutoload.php');

class EmailItem {

	private $fromEmail;
	private $toEmail;
	private $subject;
	private $message;

	function __construct($fromEmail, $toEmail, $subject, $message) {

		$this->fromEmail = $fromEmail;
		$this->toEmail = $toEmail;
		$this->subject = $subject;
		$this->message = $message;
		$this->send_email();
	}

	function send_email() {
		
		$mail = new PHPMailer;
		$mail->SMTPDebug = 4;	//comment this to hide the execution messages on the page
		$mail->isSMTP();

		//Email address info:
		$mail->Host = "smtp.gmail.com";
		$mail->SMTPAuth = true;

		$mail->Username = 'FitNessProjectPAD@gmail.com';
		$mail->Password = 'proiect2PAD';
		$mail->Port = 587;
		$mail->FromName = $this->fromEmail;

		if($this->toEmail == "feedback@fitness.com" || $this->toEmail == "support@fitness.com"){
			$mail->addAddress($mail->Username);
		}
		else{
			$mail->addAddress($this->toEmail);
		}

		$mail->isHTML(true);
		$mail->Subject = $this->subject;
		$mail->Body    = $this->message;

		if(!$mail->send()) {
			echo 'Message could not be sent.';
		} else {
		    echo 'Confirmation email sent';
		}
	}

}

$input = json_decode(file_get_contents('php://input'), true);
$email_item = new EmailItem($input['fromEmail'], $input['toEmail'], $input['subject'], $input['message']);

?>

