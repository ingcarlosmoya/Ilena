import { Component, OnInit } from '@angular/core';
import { Routine } from './../routine/routine';
import { Person } from './../people/person';
import { PhysicalExam } from './../people/physical-exam';
import { Habits } from './../people/habits';
import { PersonBasicInfoComponent } from './../people/person-basic-info/person-basic-info.component';
import { PhysicalExamComponent } from './../people/physical-exam/physical-exam.component';
import { RoutineBasicResultComponent } from '../routine/routine-basic-result/routine-basic-result.component';
import { HabitsComponent } from './../people/habits/habits.component';
import { EvaluationService } from './evaluation.service';
import { Evaluation } from './evaluation';
import { PeopleReportByPersonComponent } from './../people/people-report-by-person/people-report-by-person.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-evaluation',
  templateUrl: './evaluation.component.html',
  styleUrls: ['./evaluation.component.css']
})
export class EvaluationComponent implements OnInit {

  routines: Routine[];
  person: Person;
  physicalExam: PhysicalExam;
  habits: Habits;
  evaluation: Evaluation;
  single: any[];
  activeBreaksImage : string;

  constructor(private _evaluationService: EvaluationService,
   private _route: ActivatedRoute) { }

  ngOnInit() {

this.habits = new Habits();
 this.evaluation = new Evaluation();

 this._route.params.subscribe(params => {
          let id = (params['id']);
          console.log(id);
          this._evaluationService.getEvaluationByPatientId(id).subscribe(
      c => {
        this.evaluation = c;
        this.habits = this.evaluation.habits;
        this.routines = this.evaluation.routines;
        this.person = this.evaluation.person;
        this.physicalExam = this.evaluation.physicalExam;

        this.single = [
        {
          "name": "Work",
          "value": this.habits.seated
        },
        {
          "name": "Sleep",
          "value": this.habits.sleep
        },
        {
          "name": "Other",
          "value": 24 - (this.habits.seated + this.habits.sleep)
        }
      ];
    //   console.log(this.habits.activeBreaks);
    //   this.activeBreaksImage = 'assets/img/noActiveBreaks.jpg';
    //   if (this.habits.activeBreaks == true) {
    //   this.activeBreaksImage = 'assets/img/yesActiveBreaks.jpg';
    // }

      // this.habits.activeBreaks = true; 
      // this.getActiveBreaksImage();
      // this.habits.sport = true;
      // this.getSportImage();
      }
    );
        });


   
    this.person = new Person();
    // this.person.name = 'Tom';
    // this.person.lastName = 'Brady';
    // this.person.age = 32;
    // this.person.gender = "male";

    this.physicalExam = new PhysicalExam();
    // this.physicalExam.weight = 63.5;
    // this.physicalExam.height = 170;
    // this.physicalExam.bmi = 14;
    // this.physicalExam.bmiDiagnostic = 'Very severely underweight';

    
    // this.habits.activeBreaks = true;
    // this.habits.seated = 10;
    // this.habits.sleep = 8;
    // this.habits.sport = true;

   
    //if (this.habits != undefined) {
      // this.single = [
      //   {
      //     "name": "Work",
      //     "value": this.habits.seated
      //   },
      //   {
      //     "name": "Sleep",
      //     "value": this.habits.sleep
      //   },
      //   {
      //     "name": "Other",
      //     "value": 24 - (this.habits.seated + this.habits.sleep)
      //   }
      // ];
    //}

  }


  multi: any[];


  view: any[] = [450, 350];

  colorScheme = {
    domain: ['#5AA454', '#C7B42C', '#A10A28', '#AAAAAA']
  };

  autoScale = false;

  getSportImage() {
    var sportImage = 'assets/img/noSport.jpg';
    if (this.habits.sport == true) {
      sportImage = 'assets/img/yesSport.jpg';
    }

    return sportImage;
  }

  getSingle() {

  }

  getActiveBreaksImage() {
     var activeBreaksImage = 'assets/img/noActiveBreaks.jpg';
    if (this.habits.activeBreaks == true) {
      activeBreaksImage = 'assets/img/yesActiveBreaks.jpg';
    }

    return activeBreaksImage;
  }

}
