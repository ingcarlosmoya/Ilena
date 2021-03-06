import { Component, Input, OnInit } from '@angular/core';
import { Habits } from './../habits';

@Component({
  selector: 'app-habits',
  templateUrl: './habits.component.html',
  styleUrls: ['./habits.component.css']
})
export class HabitsComponent implements OnInit {

  @Input() habits: Habits;
  single: any[];
  constructor() { }

  ngOnInit() {

    if (this.habits != undefined) {
      this.single = [
        {
          "name": "Work",
          "value": 4
        },
        {
          "name": "Sleep",
          "value": 20
        },
        {
          "name": "Other",
          "value": 24 - (this.habits.seated + this.habits.sleep)
        }
      ];
    }
  }

  multi: any[];


  view: any[] = [450, 350];

  colorScheme = {
    domain: ['#5AA454', '#C7B42C', '#A10A28', '#AAAAAA']
  };

  autoScale = false;

  getSportImage() {
    var sportImage = 'assets/img/noSport.jpg';
    if (this.habits.sport = true) {
      sportImage = 'assets/img/yesSport.jpg';
    }

    return sportImage;
  }

  getSingle() {

  }

  getActiveBreaksImage() {
    var activeBreaksImage = 'assets/img/noActiveBreaks.jpg';
    if (this.habits.activeBreaks = true) {
      activeBreaksImage = 'assets/img/yesActiveBreaks.jpg';
    }

    return activeBreaksImage;
  }

}
