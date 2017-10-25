import { Component, OnInit } from '@angular/core';
import { Person } from './../people/person';
import { EvaluationService } from './../evaluation/evaluation.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {


  people: Person[] = []; 
  constructor(private _evaluationService: EvaluationService ) { }

  ngOnInit() {
    this._evaluationService.getPeople().subscribe(p => this.people = p);
    // var person = new Person();
    // person.name = 'Camilo';
    // person.lastName = 'Angel';
    // person.id = 'BCEB15BD-7C6B-4696-89D8-D06EF44C677E';

    // this.people.push(person);
  }

}
