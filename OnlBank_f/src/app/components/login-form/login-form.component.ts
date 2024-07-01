import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterModule, Routes, provideRouter, RouterLink, RouterLinkActive, RouterOutlet, Router } from '@angular/router';
import { ApiService } from '../../services/api.service';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.css'
})
export class LoginFormComponent implements OnInit{

  public loginForm!: FormGroup;

  constructor(
    private http: ApiService,
    private fb: FormBuilder,
    private toast: NgToastService,
    private router: Router
  ){this.loginForm = this.fb.group({
    username: ['', Validators.required],
    password: ['', Validators.required]
  })}


  ngOnInit(): void {
    
  }

  onLogin() {
    if (this.loginForm.valid) {
      this.http.loginUser(this.loginForm.value).subscribe({
        next: (res) => {
          console.log(res.message);
          this.loginForm.reset();
          this.http.storeToken(res.token);
          this.toast.success(res.message, "SUCCESS", 5000);
          this.router.navigate(['customer']);
        },
        error: (err) => {
          console.log('Full error object:', err);
          
          // Kiểm tra và xử lý các thuộc tính lỗi
          if (err.error && err.error.Message) {
            this.toast.danger(err.error.Message, "WARNING", 5000);
            console.error('Error message:', err.error.Message);
          } else if (err.message) {
            this.toast.danger(err.message, "WARNING", 5000);
            console.error('Error message:', err.message);
          } else {
            this.toast.danger('Unknown error occurred', "WARNING", 5000);
            console.error('Unknown error:', err);
          }
  
          console.log("Error");
        }
      });
    } else {
      this.toast.warning('Please enter both username and password.', "WARNING", 5000);
    }
  }
  

}
