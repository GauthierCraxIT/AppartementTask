import { Component, OnInit } from '@angular/core';
import { AuthjwtService } from '../authjwt.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private authJwtService: AuthjwtService) { }

  ngOnInit(): void {
    this.authJwtService.UpdateTokens();
  }

}
