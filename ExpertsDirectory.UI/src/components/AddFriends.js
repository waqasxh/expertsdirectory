import React, { useState, useEffect } from "react";
import { getMembers } from "../api/memberApi";
import MemberList from "./MemberList";

const AddFriends = props => {
  const [members, setMembers] = useState([]);
  const [member, setMember] = useState({
    id: 0,
    name: "",
    email: "",
    website: ""
  });

  useEffect(() => {
    const id = props.match.params.id;

    getMembers().then(_members => {
      //get self
      const self = _members.filter((member) => member.id.toString() === id)[0];

      setMember(self);

      //find self friends
      let friendIds = self.memberFriends.map(item => {
        return item.friendId
      })

      //remove self
      const filterSelf = _members.filter((member) => member.id.toString() !== id);

      //remove self friends
      const filterFriends = filterSelf.filter((member) => !friendIds.includes(member.id));

      setMembers(filterFriends);
    });
  }, [props]);

  function handleAddFriends(param) {
    console.log(param);
  }

  return (
    <>
      <h2>Add Friends for {member.name}</h2>
      <MemberList members={members} mode="AddFriends" onAddFriend={handleAddFriends} />
    </>
  );
};

export default AddFriends;
