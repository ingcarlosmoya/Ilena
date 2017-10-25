import { Component, OnInit, Input } from '@angular/core';
import { ChartsModule } from 'ng2-charts/ng2-charts';
import { Routine } from './../../routine/routine';

@Component({
  selector: 'app-people-report-by-person',
  templateUrl: './people-report-by-person.component.html',
  styleUrls: ['./people-report-by-person.component.css']
})
export class PeopleReportByPersonComponent implements OnInit {

  @Input() routine:Routine;
  constructor() { }

  ngOnInit() {
    this.setSerie();
  }


  setSerie(){
  // this.lineChartData = [
  //   {data: [65.1, 64.2, 80, 65.1, 56, 55.5, 40], label: 'Series A'}
  // ];

   this.lineChartLabels = ['January', 'February', 'March', 'April', 'May', 'June', 'July'];
  //this.lineChartLabels = ['0', '25', '50', '75', '100', '125', '150','175', '220']
  // label:[1,3,1,3,4,4,3,1,7,5,13,12,8,21,13,15,10,14,12,18,22,15,6,12,11,11,7,13,10,53,3,4,2,1,1,1]
  this.lineChartData = 
   [{data: this.routine.angles, label: this.routine.name},
  // [{data:[0,1,3,1,3,4,4,3,1,7,5,13,12,8,21,13,15,10,14,12,18,22,15,6,12,11,11,7,13,10,53,3,4,2,1,1,1,0],
  //   label:'CDC'},
  //  {data:[0,0,0,0,0,0,0,1,0,0,2,0,0,1,0,1,0,0,0,0,0,0,1,0,2,3,0,0,2,16,30,10,0,0,0,0,0,0],
  //   label:'ILENA'},
  ];
  //console.log(this.routine.labels);
  this.lineChartLabels = this.routine.labels;
  //this.lineChartLabels = [147,151,152,153,154,155,156,157,158,159,160,161,162,163,164,165,166,167,168,169,170,171,172,173,174,175,176,177,178,179,180,181,182,183,185,188,190,191];
  }
  // lineChart
  public lineChartData:Array<any>;
  public lineChartLabels:Array<any>;
  public lineChartOptions:any = {
    responsive: true
  };
  public lineChartColors:Array<any> = [
    { // grey
      backgroundColor: 'rgba(148,159,177,0.2)',
      borderColor: 'rgba(148,159,177,1)',
      pointBackgroundColor: 'rgba(148,159,177,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)'
    },
    // { // dark grey
    //   backgroundColor: 'rgba(77,83,96,0.2)',
    //   borderColor: 'rgba(77,83,96,1)',
    //   pointBackgroundColor: 'rgba(77,83,96,1)',
    //   pointBorderColor: '#fff',
    //   pointHoverBackgroundColor: '#fff',
    //   pointHoverBorderColor: 'rgba(77,83,96,1)'
    // },
    { // grey
      backgroundColor: 'rgba(255, 193, 206, 1)',
      borderColor: 'rgba(255, 99, 132, 1)',
      pointBackgroundColor: '#FF1C49',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)'
    }
  ];
  public lineChartLegend:boolean = true;
  public lineChartType:string = 'line';
 
  public randomize():void {
    let _lineChartData:Array<any> = new Array(this.lineChartData.length);
    for (let i = 0; i < this.lineChartData.length; i++) {
      _lineChartData[i] = {data: new Array(this.lineChartData[i].data.length), label: this.lineChartData[i].label};
      for (let j = 0; j < this.lineChartData[i].data.length; j++) {
        _lineChartData[i].data[j] = Math.floor((Math.random() * 100) + 1);
      }
    }
    this.lineChartData = _lineChartData;
  }
 
  // events
  public chartClicked(e:any):void {
    console.log(e);
  }
 
  public chartHovered(e:any):void {
    console.log(e);
  }

}
