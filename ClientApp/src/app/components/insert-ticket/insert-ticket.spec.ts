import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertTicket } from './insert-ticket';

describe('InsertTicket', () => {
  let component: InsertTicket;
  let fixture: ComponentFixture<InsertTicket>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InsertTicket]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InsertTicket);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
