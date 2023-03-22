import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowSGListComponent } from './show-sg-list.component';

describe('ShowSGListComponent', () => {
  let component: ShowSGListComponent;
  let fixture: ComponentFixture<ShowSGListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowSGListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowSGListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
