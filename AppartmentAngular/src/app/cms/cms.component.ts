import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ResidenceDto } from '../.dto/ResidenceDto';
import { ResidenceService } from '../residence.service';

@Component({
  selector: 'app-cms',
  templateUrl: './cms.component.html',
  styleUrls: ['./cms.component.css']
})
export class CmsComponent implements OnInit {

  constructor(public router: Router, private residenceService: ResidenceService) { }

  residences: ResidenceDto[] = [];

  ngOnInit(): void {

    this.residenceService.GetRecidences().then(data => this.residences = data);
  }

}
