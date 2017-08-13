import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PeopleReportByPersonComponent } from './people-report-by-person.component';

describe('PeopleReportByPersonComponent', () => {
  let component: PeopleReportByPersonComponent;
  let fixture: ComponentFixture<PeopleReportByPersonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PeopleReportByPersonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PeopleReportByPersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
