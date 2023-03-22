import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditSGComponent } from './add-edit-sg.component';

describe('AddEditSgComponent', () => {
  let component: AddEditSGComponent;
  let fixture: ComponentFixture<AddEditSGComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditSGComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditSGComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
