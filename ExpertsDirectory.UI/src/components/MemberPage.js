import React, { useState, useEffect } from "react";
import MemberForm from "./MemberForm";
import * as memberApi from "../api/memberApi";
import { toast } from "react-toastify";
import TextInput from "./common/TextInput";

const MemberPage = props => {
  const [errors, setErrors] = useState({});
  const [member, setMember] = useState({
    id: 0,
    name: "",
    email: "",
    website: ""
  });

  useEffect(() => {
    const id = props.match.params.id; // from the path `/members/:id`
    if (id) {
      memberApi.getMemberById(id).then(_member => setMember(_member));
    }
  }, [props.match.params.id]);

  function handleChange({ target }) {
    setMember({
      ...member,
      [target.name]: target.value
    });
  }

  function handleSearch({ target }) {

  }

  function formIsValid() {
    const _errors = {};
    //Add additional validation like length, email validity, website validity etc. here
    if (!member.name) _errors.name = "Name is required";
    if (!member.email) _errors.email = "Email is required";
    if (!member.website) _errors.website = "Website is required";

    setErrors(_errors);
    // Form is valid if the errors object has no properties
    return Object.keys(_errors).length === 0;
  }

  function handleSubmit(event) {
    event.preventDefault();
    if (!formIsValid()) return;
    memberApi.saveMember(member).then(() => {
      props.history.push("/members");
      toast.success("Member saved sucessfully.");
    }).catch(() => {
      props.history.push("/members");
      toast.error("Error saving member.");
    });
  }

  return (
    <>
      <h2>{member.id ? "Manage" : "Add"} Member</h2>
      <MemberForm
        errors={errors}
        member={member}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onSearch={handleSearch}
      />
    </>
  );
};

export default MemberPage;
