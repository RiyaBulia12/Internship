package com.example.progressedinternship;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;

public class Signup extends Activity {
	
	private EditText username;
	private EditText mobile;	
	private Button signup;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.signup);
		FontHelper.applyFont(this, findViewById(R.id.llsu), "fonts/Tautz.ttf");
		
		username = (EditText) findViewById(R.id.su_username);
		mobile = (EditText) findViewById(R.id.su_contact);		
		findViewById(R.id.btn_register).setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View arg0) {
				//username
				final String text = username.getText().toString();
				if (!isValidText(text)) {
					username.setError("Invalid Username");
				}
				//mobile
				final String m = mobile.getText().toString();
				if (!isValidmobile(m)) {
					mobile.setError("Invalid Mo");
				}
			}
		});
	}

	// validating for alphabets
	private boolean isValidText(String name) {
		String text_pattern = "[a-zA-Z ]*$";

		Pattern pattern = Pattern.compile(text_pattern);
		Matcher matcher = pattern.matcher(name);
		return matcher.matches();
	}
	
	//validating for mobile no.
	private boolean isValidmobile(String m) {
		String phone_pattern = "\\d{3}-\\d{7}";

		Pattern pattern = Pattern.compile(phone_pattern);
		Matcher matcher = pattern.matcher(m);
		return matcher.matches();
	}
}