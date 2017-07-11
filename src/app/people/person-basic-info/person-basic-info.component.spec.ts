import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonBasicInfoComponent } from './person-basic-info.component';

describe('PersonBasicInfoComponent', () => {
  let component: PersonBasicInfoComponent;
  let fixture: ComponentFixture<PersonBasicInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonBasicInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonBasicInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
