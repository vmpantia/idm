import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSGComponent } from './add-sg.component';

describe('AddSGComponent', () => {
  let component: AddSGComponent;
  let fixture: ComponentFixture<AddSGComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddSGComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddSGComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
