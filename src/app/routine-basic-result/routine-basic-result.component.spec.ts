import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RoutineBasicResultComponent } from './routine-basic-result.component';

describe('RoutineBasicResultComponent', () => {
  let component: RoutineBasicResultComponent;
  let fixture: ComponentFixture<RoutineBasicResultComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RoutineBasicResultComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RoutineBasicResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
