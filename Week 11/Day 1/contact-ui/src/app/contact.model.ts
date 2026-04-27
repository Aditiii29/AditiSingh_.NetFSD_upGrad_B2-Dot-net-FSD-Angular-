// contact.model.ts
// ✅ This defines the structure/shape of one Contact object

export interface Contact {
  contactId: number;
  name:      string;
  email:     string;
  phone:     string;
  isActive:  boolean;
}