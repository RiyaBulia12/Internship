package com.example.progressedinternship;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;

public class Fragement_mycart extends Activity{

	 @Override
	 protected void onCreate(Bundle savedInstanceState) {
	        super.onCreate(savedInstanceState);
	        getActionBar().hide();
	        setContentView(R.layout.fragment_mycart);
	        FontHelper.applyFont(this, findViewById(R.id.mychecklist), "fonts/Tautz Medium.ttf");
	 }
	 
	//previous
	    public void img_pre(View view) 
		{   Intent intent = new Intent(Fragement_mycart.this, MainActivity.class);
		    startActivity(intent);
		}
}
