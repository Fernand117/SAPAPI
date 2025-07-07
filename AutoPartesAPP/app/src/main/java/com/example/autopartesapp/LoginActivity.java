package com.example.autopartesapp;

import android.os.Bundle;
import android.view.View;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.example.autopartesapp.utils.GenerateToast;
import com.google.android.material.button.MaterialButton;
import com.google.android.material.textfield.TextInputLayout;

public class LoginActivity extends AppCompatActivity {

    private TextInputLayout txtUsuario, txtPassword;
    private MaterialButton btnLogin, btnRegistro;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_login);

        getSupportActionBar().hide(); // Oculta la barra de acción

        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        txtUsuario = findViewById(R.id.txtUsuario);
        txtPassword = findViewById(R.id.txtPassword);
        btnLogin = findViewById(R.id.btnLogin);
        btnRegistro = findViewById(R.id.btnRegistro);

        GenerateToast generateToast = new GenerateToast();

        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (txtUsuario.getEditText().getText().toString().isEmpty()) {
                    generateToast.generateToast(LoginActivity.this, "El campo usuario es requerido").show();
                    txtUsuario.requestFocus();
                    return;
                }

                if (txtPassword.getEditText().getText().toString().isEmpty()) {
                    generateToast.generateToast(LoginActivity.this, "El campo contraseña es requerido").show();
                    txtPassword.requestFocus();
                    return;
                }
            }
        });
    }
}