import React, { useState, useEffect } from "react";
import { getMembers } from "../api/memberApi";
import MemberList from "./MemberList";
import { Link } from "react-router-dom";

function MembersPage() {
  const [members, setMembers] = useState([]);

  useEffect(() => {
    getMembers().then(_members => setMembers(_members));
  }, []);

  return (
    <>
      <h2>Members</h2>
      <Link className="btn btn-primary button" to="/member">
        Add Member
      </Link>
      <MemberList members={members} mode="MembersPage" />
    </>
  );
}

export default MembersPage;
