import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public router: Router, private httpClient: HttpClient, public formBuilder: FormBuilder, private authService: AuthService) { }

  loginForm!: FormGroup;
  submitted = false;

  ngOnInit(): void {

    this.loginForm = this.formBuilder.group({

      Email: ["", [Validators.required]],
      Password: ["", [Validators.required]]
    });
  }

  get form() {
    return this.loginForm.controls;
  }


  onSubmit() {
    this.submitted = true;

    if (!this.loginForm.valid)
      return;


    var email = this.loginForm.controls["Email"].value;
    var password = this.loginForm.controls["Password"].value;

    this.authService.Login(email, password).then(data => {
      if (data.accessToken == "")
        this.loginForm.controls["Password"].setErrors({ matchCreds: true })

      else {
        localStorage.setItem("accesstoken", data.accessToken);
        localStorage.setItem("refreshtoken", data.refreshToken);
        this.router.navigate(["/"]);
      }
    })
  }

}
