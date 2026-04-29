
export interface Contact {
  contactId: number;   // A unique ID for each contact (e.g., 1, 2, 3...)
  name: string;        // The contact's full name
  email: string;       // The contact's email address
  phone: string;       // The contact's phone number
  isActive: boolean;   // Whether this contact is currently active (true/false)
}