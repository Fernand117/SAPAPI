package com.example.autopartesapp.utils;

import android.content.Context;
import android.view.Gravity;
import android.widget.Toast;

public class GenerateToast {
    public Toast generateToast(Context context, String message) {
        Toast toast = Toast.makeText(context, message, Toast.LENGTH_SHORT);
        toast.setGravity(Gravity.CENTER, 0, 0);
        return toast;
    }
}
