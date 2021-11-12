import { handleResponse, handleError } from "./apiUtils";
import * as config from "../config";
const baseUrl = config.API_BASE_PATH + "member";

export function getMembers() {
  return fetch(baseUrl)
    .then(handleResponse)
    .catch(handleError);
}

export function getMemberById(id) {
  return fetch(baseUrl + "/" + id)
    .then(response => {
      if (!response.ok) throw new Error("Network response was not ok.");
      return response.json().then(member => {
        if (member == null) throw new Error("Member not found: " + id);
        return member;
      });
    })
    .catch(handleError);
}

export function saveMember(member) {
  return fetch(baseUrl + (member.id ? ("/" + member.id) : ""), {
    method: member.id ? "PUT" : "POST", // POST for create, PUT to update when id already exists.
    headers: { "content-type": "application/json" },
    body: JSON.stringify({
      ...member
    })
  })
    .then(handleResponse)
    .catch(handleError);
}

export function addFriend(member, friendId) {
  return fetch(baseUrl + (member.id ? ("/" + member.id) : ""), {
    method: "PUT",
    headers: { "content-type": "application/json" },
    body: JSON.stringify({
      ...member
    })
  })
    .then(handleResponse)
    .catch(handleError);
}

export function deleteMember(id) {
  return fetch(baseUrl + id, { method: "DELETE" })
    .then(handleResponse)
    .catch(handleError);
}
