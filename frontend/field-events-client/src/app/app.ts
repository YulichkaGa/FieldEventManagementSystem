import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EventSignalrService } from './services/event-signalr.service';
import { EventsApiService } from './services/events-api.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule
  ],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App implements OnInit {

  protected readonly title = signal('field-events-client');

  events: any[] = [];

  constructor(
    private eventSignalrService: EventSignalrService,
    private eventsApiService: EventsApiService
  ) { }

  ngOnInit(): void {

    // טעינת כל האירועים מהשרת
    this.eventsApiService.getEvents().subscribe(events => {
      this.events = events;
    });

    // חיבור ל-SignalR
    this.eventSignalrService.startConnection((event: any) => {
      console.log('New Event:', event);
      this.events.unshift(event);
    });
  }

  assign(eventId: string): void {

    this.eventsApiService
      .assignTechnician(eventId)
      .subscribe(() => {

        const event = this.events.find(e => e.id === eventId);

        if (event) {
          event.assignedTechnician = 'David Cohen';
          event.status = 'Assigned';
        }

      });

  }
}
