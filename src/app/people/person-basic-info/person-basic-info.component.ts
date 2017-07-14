import { Component, Input, OnInit } from '@angular/core';
import { Person } from './../person';

@Component({
  selector: 'app-person-basic-info',
  templateUrl: './person-basic-info.component.html',
  styleUrls: ['./person-basic-info.component.css']
})
export class PersonBasicInfoComponent implements OnInit {

  @Input() person: Person;
  scheme = {
    domain: ['#FF8000']
  }
  view: any[] = [300, 100];


  constructor() { }

  ngOnInit() {
  }

  getGenderImage() {
    var genderImage = 'assets/img/female.jpg';
    if (this.person.gender = 'male') {
      genderImage = 'assets/img/male.jpg';
    }

    return genderImage;

  }
}
