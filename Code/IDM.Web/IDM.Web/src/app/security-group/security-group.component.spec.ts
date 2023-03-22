import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SecurityGroupComponent } from './security-group.component';

describe('SecurityGroupComponent', () => {
  let component: SecurityGroupComponent;
  let fixture: ComponentFixture<SecurityGroupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SecurityGroupComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SecurityGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
