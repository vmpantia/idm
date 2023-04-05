import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditSgComponent } from './edit-sg.component';

describe('EditSgComponent', () => {
  let component: EditSgComponent;
  let fixture: ComponentFixture<EditSgComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditSgComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditSgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
