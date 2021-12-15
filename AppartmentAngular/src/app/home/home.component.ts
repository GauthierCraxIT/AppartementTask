import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ResidenceDto } from '../.dto/ResidenceDto';
import { AuthjwtService } from '../authjwt.service';
import { ResidenceService } from '../residence.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private authJwtService: AuthjwtService, private residenceService: ResidenceService, public router: Router) { }

  isAdmin = false;
  residences: ResidenceDto[] = [];

  ngOnInit(): void {
    this.authJwtService.IsAdmin()
      .then(res => this.isAdmin = res);


    this.residenceService.GetRecidences().then(data => {
      this.residences = data;
    });
  }



}
