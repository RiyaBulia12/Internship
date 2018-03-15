package com.example.progressedinternship;

import java.util.regex.Matcher;
import java.util.regex.Pattern;
import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;

public class Signin extends Activity {

    private Button login;
	private EditText username;
	private EditText password;
	
	//link for forgot password 
		 public void tv_forgot_pwd(View view) 
			{
			    Intent intent = new Intent(this, Forgotpwd.class);
			    startActivity(intent);
			}
		 
		//link for signup  
		 public void tv_create_acc(View view) 
			{
			    Intent intent = new Intent(this, Signup.class);
			    startActivity(intent);
			}
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.signin);
		FontHelper.applyFont(this, findViewById(R.id.llsi), "fonts/Tautz.ttf");
		
		username = (EditText) findViewById(R.id.si_username);
		password = (EditText) findViewById(R.id.si_pwd);

		findViewById(R.id.btn_login).setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View arg0) {

				final String text = username.getText().toString();
				if (!isValidText(text)) {
					username.setError("Invalid Username");
				}

				final String pass = password.getText().toString();
				if (!isValidPassword(pass)) {
					password.setError("Invalid Password");
				}

			}
		});
	}

	// validating email id
	private boolean isValidText(String name) {
		String text_pattern = "[a-zA-Z ]*$";

		Pattern pattern = Pattern.compile(text_pattern);
		Matcher matcher = pattern.matcher(name);
		return matcher.matches();
	}

	// validating password with retype password
	private boolean isValidPassword(String pass) {
		if (pass != null && pass.length() > 6) {
			return true;
		}
		return false;
	}
}