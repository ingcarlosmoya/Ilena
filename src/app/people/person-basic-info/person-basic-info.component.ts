import { Component, Input, OnInit } from '@angular/core';
import { Person } from './../person';

@Component({
  selector: 'app-person-basic-info',
  templateUrl: './person-basic-info.component.html',
  styleUrls: ['./person-basic-info.component.css']
})
export class PersonBasicInfoComponent implements OnInit {

  @Input() person:Person

  constructor() { }

  ngOnInit() {
  }

}
