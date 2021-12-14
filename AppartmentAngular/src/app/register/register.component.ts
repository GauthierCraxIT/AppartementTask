import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(public router: Router, private httpClient: HttpClient, public formBuilder: FormBuilder, private authService: AuthService) { }

  registerForm!: FormGroup;
  submitted = false;

  ngOnInit(): void {

    this.registerForm = this.formBuilder.group({
      UserName: ["", [Validators.required, Validators.minLength(4)]],
      FirstName: ["", [Validators.required, Validators.minLength(2)]],
      LastName: ["", [Validators.required, Validators.minLength(3)]],
      Email: ["", [Validators.required, Validators.minLength(6)]],
      Password: ["", [Validators.required, Validators.minLength(6)]],
      RepeatPassword: ["", [Validators.required, Validators.minLength(6)]]
    })
  }

  get form() {
    return this.registerForm.controls;
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.registerForm.invalid)
      return;

    var username = this.registerForm.controls["UserName"].value;
    var firstname = this.registerForm.controls["FirstName"].value;
    var lastname = this.registerForm.controls["LastName"].value;
    var email = this.registerForm.controls["Email"].value;
    var password = this.registerForm.controls["Password"].value;
    var repeatpassword = this.registerForm.controls["RepeatPassword"].value;

    if (password !== repeatpassword) {
      this.registerForm.controls["RepeatPassword"].setErrors({ matchPasswords : true})
      return;
    }

    if (email.indexOf('@') <= 0) {
      this.registerForm.controls["Email"].setErrors({ validEmail: true})
      return;
    }

    this.authService.Register(username,firstname, lastname, email, password).then(data => {
      if (data.accessToken == "") {
        this.registerForm.controls["RepeatPassword"].setErrors({ somethingFailed: true })
      }

      else {
        localStorage.setItem("accesstoken", data.accessToken);
        localStorage.setItem("refreshtoken", data.refreshToken);
        this.router.navigate(["/"]);
      }


    })
  }
}
