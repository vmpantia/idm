import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SGFormComponent } from './sg-form.component';

describe('SGFormComponent', () => {
  let component: SGFormComponent;
  let fixture: ComponentFixture<SGFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SGFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SGFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
