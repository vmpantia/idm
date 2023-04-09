import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditSGComponent } from './edit-sg.component';

describe('EditSGComponent', () => {
  let component: EditSGComponent;
  let fixture: ComponentFixture<EditSGComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditSGComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditSGComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
