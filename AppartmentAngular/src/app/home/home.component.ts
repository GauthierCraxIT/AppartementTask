import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthjwtService } from '../authjwt.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private authJwtService: AuthjwtService, public router: Router) { }

  isAdmin = false;

  ngOnInit(): void {
    this.authJwtService.IsAdmin()
      .then(res => this.isAdmin = res);
  }



}
