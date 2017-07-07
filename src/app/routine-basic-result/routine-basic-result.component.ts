import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-routine-basic-result',
  templateUrl: './routine-basic-result.component.html',
  styleUrls: ['./routine-basic-result.component.css']
})
export class RoutineBasicResultComponent implements OnInit {

  routines:string[];
  
  constructor() { }

  ngOnInit() {

  }

}
