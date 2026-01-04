import {Box, Heading, HStack, Separator, Text, VStack} from "@chakra-ui/react";

import ProfileSectionCard from "./ProfileSectionCard.jsx";

import {FaAt, FaFacebook, FaPhoneAlt, FaGithub, FaLinkedin, FaTelegram, FaWhatsapp} from "react-icons/fa";

const ProfileContacts = ({user}) => {
    const whatsappPhone = user.phone ? user.phone.replace(/\D/g, '') : '';
    const telPhone = user.phone ? user.phone.replace(/[^\d+]/g, '') : '';
    return (
        <ProfileSectionCard h="full">
            <VStack align={'left'} gap={6}>
                <Heading
                    fontSize='2xl'
                    fontWeight='800'
                    letterSpacing='-0.02em'
                    color="text.primary"
                >
                    Contacts
                </Heading>
                <VStack align="stretch" gap={4}>
                    {user?.email && (
                        <HStack gap={3}>
                            <Box color="brand.500">
                                <FaAt size={18}/>
                            </Box>
                            <Text
                                as="a"
                                href={`mailto:${user.email}`}
                                fontSize="md"
                                color="text.secondary"
                                _hover={{color: "brand.500"}}
                                transition="color 0.2s"
                            >
                                {user.email}
                            </Text>
                        </HStack>
                    )}
                    {user?.phone && (
                        <HStack gap={3}>
                            <Box color="brand.500">
                                <FaPhoneAlt size={16}/>
                            </Box>
                            <Text
                                as="a"
                                href={`tel:${telPhone}`}
                                fontSize="md"
                                color="text.secondary"
                                _hover={{color: "brand.500"}}
                                transition="color 0.2s"
                            >
                                {user.phone}
                            </Text>
                        </HStack>
                    )}
                </VStack>
                <Separator borderColor="border.subtle"/>
                <HStack gap={5} justify="center" pt={2}>
                    <Box as="a" href="#" color="text.secondary" _hover={{color: "brand.500"}} transition="all 0.2s"><FaLinkedin size={22}/></Box>
                    <Box as="a" href="#" color="text.secondary" _hover={{color: "brand.500"}} transition="all 0.2s"><FaGithub size={22}/></Box>
                    <Box as="a" href="#" color="text.secondary" _hover={{color: "brand.500"}} transition="all 0.2s"><FaTelegram size={22}/></Box>
                    <Box as="a" href="#" color="text.secondary" _hover={{color: "brand.500"}} transition="all 0.2s"><FaFacebook size={22}/></Box>
                    <Box 
                        as="a" 
                        href={`https://wa.me/${whatsappPhone}`}
                        target="_blank"
                        rel="noopener noreferrer"
                        color="text.secondary"
                        _hover={{color: "brand.500"}}
                        transition="all 0.2s"
                    >
                        <FaWhatsapp size={22}/>
                    </Box>
                </HStack>
            </VStack>
        </ProfileSectionCard>
    )
};

export default ProfileContacts;