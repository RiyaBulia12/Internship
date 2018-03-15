package com.example.progressedinternship;

import java.util.Timer;
import java.util.TimerTask;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.ImageView;


public class Welcomescreen extends Activity {

	/* public int currentimageindex=0;
	    //  Timer timer;
	    //  TimerTask task;
	    ImageView slidingimage;
	  
	    private int[] IMAGE_IDS = {
	          *//*R.drawable.banner1,
	          R.drawable.banner2, 
	          R.drawable.banner3*//*
	      };*/

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getActionBar().hide();
        setContentView(R.layout.welcomescreen);
        FontHelper.applyFont(this, findViewById(R.id.rlws), "fonts/RobotoCondensed-Regular.ttf.ttf");
        final Handler mHandler = new Handler();

     /*   // Create runnable for posting
        final Runnable mUpdateResults = new Runnable() {
            @Override
			public void run() {           
                AnimateandSlideShow();
            }
        };
        int delay = 0; // delay for 0 sec.
        int period = 9000; // repeat every 4 sec.
        Timer timer = new Timer();
        
        timer.scheduleAtFixedRate(new TimerTask() {
        @Override
		public void run() {
             mHandler.post(mUpdateResults);
        }
        }, delay, period);*/
}

/**
* Helper method to start the animation on the splash screen
*/
 /*private void AnimateandSlideShow() {
	slidingimage = (ImageView)findViewById(R.id.banner1);
 slidingimage.setImageResource(IMAGE_IDS[currentimageindex%IMAGE_IDS.length]);  
 currentimageindex++;
 Animation rotateimage = AnimationUtils.loadAnimation(this, R.anim.slide_out_left);
 slidingimage.startAnimation(rotateimage);
}   */
    
    //skip
    public void btn_skip(View view) 
	{   Intent intent = new Intent(Welcomescreen.this, MainActivity.class);
	    startActivity(intent);
	}
    
    //signin
    public void btn_signin(View view) 
	{	Intent intent = new Intent(Welcomescreen.this, Signin.class);
	    startActivity(intent);
	}
    
    //signup
    public void btn_signup(View view) 
	{   Intent intent = new Intent(Welcomescreen.this, Signup.class);
	    startActivity(intent);
	}
}
