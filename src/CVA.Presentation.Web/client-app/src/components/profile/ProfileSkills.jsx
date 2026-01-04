import {Heading, Flex, Badge, VStack, Text} from "@chakra-ui/react";

import ProfileSectionCard from "./ProfileSectionCard.jsx";

const ProfileSkills = ({user}) => {
    return (
        <ProfileSectionCard>
            <VStack align={'left'} gap={6}>
                <Heading
                    fontSize='2xl'
                    fontWeight='800'
                    letterSpacing='-0.02em'
                    color="text.primary"
                >
                    Skills
                </Heading>
                {user?.skills?.length > 0 ? (
                    <Flex
                        gap={3}
                        wrap="wrap"
                    >
                        {user.skills.map(skill => (
                            <Badge
                                key={skill}
                                size='lg'
                                variant="subtle"
                                colorPalette="indigo"
                                borderRadius="full"
                                px={4}
                                py={1}
                                textTransform="none"
                                fontSize="sm"
                                fontWeight="600"
                            >
                                {skill}
                            </Badge>
                        ))}
                    </Flex>
                ) : (
                    <Text
                        color="text.secondary"
                        fontStyle="italic"
                    >
                        No skills specified.
                    </Text>
                )}
            </VStack>
        </ProfileSectionCard>
    )
};

export default ProfileSkills;