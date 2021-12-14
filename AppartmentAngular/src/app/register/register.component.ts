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

      FirstName: ["", [Validators.required]],
      LastName: ["", [Validators.required]],
      Email: ["", [Validators.required]],
      Password: ["", [Validators.required]],
      RepeatPassword: ["", [Validators.required]],
    })
  }

  get form() {
    return this.registerForm.controls;
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.registerForm.invalid)
      return;

    var firstname = this.registerForm.controls["FirstName"].value;
    var lastname = this.registerForm.controls["LastName"].value;
    var email = this.registerForm.controls["Email"].value;
    var password = this.registerForm.controls["Password"].value;
    var repeatpassword = this.registerForm.controls["RepeatPassword"].value;

    if (password !== repeatpassword) {
      this.registerForm.controls["RepeatPassword"].setErrors({ matchPasswords : true})
      return;
    }

    this.authService.Register(firstname, lastname, email, password).then(data => {
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
