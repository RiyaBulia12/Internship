package com.example.progressedinternship;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.EditText;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Forgotpwd extends Activity {

	private EditText emailEditText;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.forgotpwd);
		FontHelper.applyFont(this, findViewById(R.id.fpwd), "fonts/Tautz.ttf");
		
		emailEditText = (EditText) findViewById(R.id.email);
		findViewById(R.id.btn_resetpwd).setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View arg0) {

				final String email = emailEditText.getText().toString();
				if (!isValidEmail(email)) {
					emailEditText.setError("Invalid Email");
				}
			}
		});
	}
	
	// validating email id
		private boolean isValidEmail(String email) {
			String EMAIL_PATTERN = "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@"
					+ "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";

			Pattern pattern = Pattern.compile(EMAIL_PATTERN);
			Matcher matcher = pattern.matcher(email);
			return matcher.matches();
		}

	/*@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.forgotpwd, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.action_settings) {
			return true;
		}
		return super.onOptionsItemSelected(item);
	}*/
}
