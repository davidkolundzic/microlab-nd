import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavMenuLeftComponent } from './nav-menu-left.component';

describe('NavMenuLeftComponent', () => {
  let component: NavMenuLeftComponent;
  let fixture: ComponentFixture<NavMenuLeftComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavMenuLeftComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavMenuLeftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
