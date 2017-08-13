import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { RoutineBasicResultComponent } from './routine/routine-basic-result/routine-basic-result.component';
import { EvaluationComponent } from './evaluation/evaluation.component';
import { PersonBasicInfoComponent } from './people/person-basic-info/person-basic-info.component';
import { PhysicalExamComponent } from './people/physical-exam/physical-exam.component';
import { HabitsComponent } from './people/habits/habits.component';
import { EvaluationService } from './evaluation/evaluation.service';
import { PeopleReportByPersonComponent } from './people/people-report-by-person/people-report-by-person.component';
import { ChartsModule } from 'ng2-charts/ng2-charts';

@NgModule({
  declarations: [
    AppComponent,
    RoutineBasicResultComponent,
    EvaluationComponent,
    PersonBasicInfoComponent,
    PhysicalExamComponent,
    HabitsComponent,
    PeopleReportByPersonComponent
  ],
  imports: [
    BrowserModule,
    NgbModule.forRoot(),
    NgxChartsModule,
    BrowserAnimationsModule,
    HttpModule,
    ChartsModule
  ],
  providers: [EvaluationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
