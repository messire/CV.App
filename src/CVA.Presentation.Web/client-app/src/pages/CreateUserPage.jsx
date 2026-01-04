import {Container, Heading, VStack, Input, Button, Box} from "@chakra-ui/react";
import {useState} from "react";

import {useUserStore} from "../stores/users.store.js";

import {useColorModeValue} from "../components/ui/color-mode.jsx";
import {toaster} from "../components/ui/toaster.jsx";

const CreateUserPage = () => {
    const [newUser, setNewUser] = useState({
        name: "",
        surname: "",
        email: "",
        phone: "",
    });

    const {createUser} = useUserStore()
    const handleAddUser = async () => {
        if (!newUser.name || !newUser.surname || !newUser.email || !newUser.phone) {
            toaster.create({description: "All fields are required.", type: "error",});
            return;
        }

        const {success, message} = await createUser(newUser);
        const toastType = success ? "success" : "error";

        toaster.create({description: message, type: toastType, closable: true});
        setNewUser({name: "", surname: "", email: "", phone: ""});
    };

    return <Container maxW={"Container.sm"}>
        <VStack gap={4}>
            <Heading
                size="xl"
                textAlign="center"
                p={8}
            >
                Create User
            </Heading>
            <Box w={"50%"}
                 bg={useColorModeValue("gray.50", "gray.800")}
                 p={6}
                 rounded={"lg"}
                 shadow={"lg"}
            >
                <VStack gap={4}>
                    <Input
                        placeholder="Photo"
                        name='photo'
                        value={newUser.photo}
                        borderColor={useColorModeValue("gray.200", "gray.700")}
                        onChange={(e) => setNewUser({...newUser, photo: e.target.value})}
                    />
                    <Input
                        placeholder="Name"
                        name='name'
                        value={newUser.name}
                        borderColor={useColorModeValue("gray.200", "gray.700")}
                        onChange={(e) => setNewUser({...newUser, name: e.target.value})}
                    />
                    <Input
                        placeholder="Surname"
                        name='surname'
                        value={newUser.surname}
                        borderColor={useColorModeValue("gray.200", "gray.700")}
                        onChange={(e) => setNewUser({...newUser, surname: e.target.value})}
                    />
                    <Input
                        placeholder="email"
                        name='email'
                        type="email"
                        value={newUser.email}
                        borderColor={useColorModeValue("gray.200", "gray.700")}
                        onChange={(e) => setNewUser({...newUser, email: e.target.value})}
                    />
                    <Input
                        placeholder="Phone"
                        name='phone'
                        type="phone"
                        value={newUser.phone}
                        borderColor={useColorModeValue("gray.200", "gray.700")}
                        onChange={(e) => setNewUser({...newUser, phone: e.target.value})}
                    />
                    <Button
                        colorScheme="teal"
                        onClick={handleAddUser}
                        w='full'
                    >
                        Create
                    </Button>
                </VStack>
            </Box>
        </VStack>
    </Container>;
}

export default CreateUserPage;